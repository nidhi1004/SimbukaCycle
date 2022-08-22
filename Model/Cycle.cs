using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimCycle.Model
{
    public partial class Cycle
    {
        public int Id { get; set; }
        public int? GearLevel { get; set; }
        public int? TotalGearLevels
        {
            get
            {
                return (int)TotalGearLevel;
            }
            set
            {
                TotalGearLevel = (Total_GearLevels)value;
            }
        }
        public int? RearwheelCircumference { get; set; }
        public double? GearRatio { get; set; }
        public int ChainRingTeeth { get; set; }
        public int? SprocketTeeth { get; set; }
        public double? RearWheelSize 
        {
            get
            {
                return rearWheelSize;
            }

            set
            {
                rearWheelSize = Math.Round((double)(value * 0.0254),3);
            }
        
        }
        public double? FrontWheelSize
        {
            get
            {
                return frontWheelSize;
            }

            set
            {
                frontWheelSize = Math.Round((double)(value * 0.0254), 3);
            }

        }

        public enum Total_GearLevels
        {
            CheapGear =7,
            ExpensiveGear = 30
        }
        [NotMapped]
        public Total_GearLevels TotalGearLevel { get; set; }
        private double rearWheelSize { get; set; }
        
        private double frontWheelSize { get; set; }
    }


    //Extension Class for Enum
    public static class StringExtension
    {
        public static T ParseEnum<T>(this string value)
        {
            return (T)Enum.Parse(typeof(T), value);
        }
    }
}
