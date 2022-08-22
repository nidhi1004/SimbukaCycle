using System.Net;

namespace SimCycle.Service
{
    public class BicycleService : IBicycle
    {
        private SimCycleContext context;
        public APIResponse<Cycle> APIResponse { get; set; }
        public BicycleService(SimCycleContext simCycleContext)
        {
            context = simCycleContext;
        }
        public void IncreaseGear()
        {
            Cycle cycle = context.Cycles.Where(x => x.Id == 2).SingleOrDefault();
            if (cycle != null && cycle.GearLevel >= 1 && (int)cycle.GearLevel < (int)Model.Cycle.Total_GearLevels.CheapGear)
            {
                cycle.GearLevel += 1;
                context.Update(cycle);
                context.SaveChanges();
                APIResponse = new APIResponse<Cycle>
                {
                    Succeeded = true,
                    Message = "Successfully Increased Gear Level by 1",
                    Data = new Cycle { GearLevel = cycle.GearLevel, TotalGearLevels = cycle.TotalGearLevels },
                    StatusCode = HttpStatusCode.OK
                };

            }
            else
            {
                APIResponse = new APIResponse<Cycle>
                {
                    Succeeded = false,
                    Message = "Cannot increase gear beyond the capacity",
                    Data = new Cycle { GearLevel = cycle.GearLevel, TotalGearLevels = cycle.TotalGearLevels },
                    StatusCode = HttpStatusCode.BadRequest
                };
            }
        }

        public void DecreaseGear()
        {
            Cycle cycle = context.Cycles.Where(x => x.Id == 2).SingleOrDefault();
            if (cycle != null && cycle.GearLevel >= 1 && (int)cycle.GearLevel <= (int)Model.Cycle.Total_GearLevels.CheapGear)
            {
                cycle.GearLevel -= 1;
                context.Update(cycle);
                context.SaveChanges();
                APIResponse = new APIResponse<Cycle>
                {
                    Succeeded = true,
                    Message = "Successfully Decreased Gear Level by 1",
                    Data = new Cycle { GearLevel = cycle.GearLevel, TotalGearLevels = cycle.TotalGearLevels },
                    StatusCode = HttpStatusCode.OK
                };

            }
            else
            {
                APIResponse = new APIResponse<Cycle>
                {
                    Succeeded = false,
                    Message = "Cannot decrease gear beyond least.",
                    Data = new Cycle { GearLevel = cycle.GearLevel, TotalGearLevels = cycle.TotalGearLevels },
                    StatusCode = HttpStatusCode.BadRequest
                };
            }
        }

        public float Cycle(int no_of_rotations)
        {
            try
            {
                float distance = 0;
                Cycle cycle = context.Cycles.Where(x => x.Id == 2).SingleOrDefault();
                if (cycle != null)
                {
                    var a = Math.PI * cycle.RearWheelSize;
                    var b = GearRatio_Calculation(cycle);
                    var c = (double)no_of_rotations;
                    distance = (float)Math.Round((double)(c * a*b), 3);
                    APIResponse = new APIResponse<Cycle>
                    {
                        Succeeded = true,
                        Message = distance.ToString(),
                        StatusCode = HttpStatusCode.OK
                    };

                }
                else
                {
                    APIResponse = new APIResponse<Cycle>
                    {
                        Succeeded = false,
                        Message = "Could not evaluate Distance",
                        Data = new Cycle { GearRatio= cycle.GearRatio, ChainRingTeeth = cycle.ChainRingTeeth, GearLevel = cycle.GearLevel },
                        StatusCode = HttpStatusCode.BadRequest
                    };
                }
                return distance;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
         
        private int Sprocket_TeethCalculation(Cycle cycle)
        {
            try
            {
                int teeth = 0;
                if (cycle.TotalGearLevels == (int)Model.Cycle.Total_GearLevels.CheapGear)
                {
                    teeth = (int)(30 - 2 * cycle.GearLevel);
                }
                else
                {
                    teeth = (int)(46 - Math.Floor((double)(1.2 * cycle.GearLevel)));
                }
                cycle.SprocketTeeth = teeth;
                context.Update(cycle);
                context.SaveChanges();

                return teeth;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private double GearRatio_Calculation(Cycle cycle)
        {
            try
            {
                var sprocket_Teeth = Sprocket_TeethCalculation(cycle);
                double gearRatio = (double)cycle.ChainRingTeeth / (double)sprocket_Teeth;
                cycle.GearRatio = gearRatio;
                context.Update(cycle);
                context.SaveChanges();

                return gearRatio;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
