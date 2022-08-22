namespace SimCycle.Service
{
    public interface IBicycle
    {
        APIResponse<Cycle> APIResponse { get; set;  } 
        void IncreaseGear();
        void DecreaseGear();
        float Cycle(int no_of_rotations);
    }
}
