namespace AspireSystems.TakeYourJob.Infrastructure.Extensions
{
    public static class ObjectExtensions
    {
        public static void CopyPropertiesFrom(this object destination, object source)
        {
            var sourceProperties = source.GetType().GetProperties();
            var destinationProperties = destination.GetType().GetProperties();

            foreach (var sourceProperty in sourceProperties)
            {
                foreach (var destinationProperty in destinationProperties)
                {
                    if (sourceProperty.Name == destinationProperty.Name && sourceProperty.PropertyType == destinationProperty.PropertyType)
                    {
                        destinationProperty.SetValue(destination, sourceProperty.GetValue(source));
                        break;
                    }
                }
            }
        }
    }
}
