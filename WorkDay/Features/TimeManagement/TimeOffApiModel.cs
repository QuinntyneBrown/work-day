using WorkDay.Data.Models;

namespace WorkDay.Features.TimeManagement
{
    public class TimeOffApiModel
    {        
        public int Id { get; set; }
        public string Name { get; set; }

        public static TModel FromTimeOff<TModel>(TimeOff timeOff) where
            TModel : TimeOffApiModel, new()
        {
            var model = new TModel();
            model.Id = timeOff.Id;
            return model;
        }

        public static TimeOffApiModel FromTimeOff(TimeOff timeOff)
            => FromTimeOff<TimeOffApiModel>(timeOff);

    }
}
