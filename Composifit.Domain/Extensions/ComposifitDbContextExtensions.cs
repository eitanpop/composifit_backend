using Composifit.Core.Entities;
using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections;

namespace Composifit.Domain.Extensions
{
    public static class ComposifitDbContextExtensions
    {
        public static void DirtifyModel(this ComposifitDbContext context, Entity entity)
        {
            context.Entry(entity).State = entity.Id > 0 ? EntityState.Modified : EntityState.Added;

            IEnumerable<PropertyInfo> properties = entity.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance)?
            .Where(x => x.PropertyType == typeof(Entity) || x.GetValue(entity) is IEnumerable);
            if (properties == null || !properties.Any())
                return;
            properties.ToList().ForEach(property =>
            {
                var value = property.GetValue(entity);
                if (value is Entity)
                {
                    DirtifyModel(context, (Entity)value);
                    return;
                }

                foreach (var item in (IEnumerable)property.GetValue(entity))
                {
                    if (!(item is Entity))
                        return;
                    DirtifyModel(context, (Entity)item);
                }
            });
        }
    }
}
