using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NightscoutShareServer.Utils
{
    public class SlopeConvert
    {
        public static ShareGlucoseSlopeOrdinals NsDirectionToShareTrend(string direction)
        {
            switch (direction)
            {
                case "DoubleUp":
                    return ShareGlucoseSlopeOrdinals.DOUBLE_UP;

                case "SingleUp":
                    return ShareGlucoseSlopeOrdinals.SINGLE_UP;

                case "FortyFiveUp":
                    return ShareGlucoseSlopeOrdinals.UP_45;

                case "Flat":
                    return ShareGlucoseSlopeOrdinals.FLAT;

                case "FortyFiveDown":
                    return ShareGlucoseSlopeOrdinals.DOWN_45;

                case "SingleDown":
                    return ShareGlucoseSlopeOrdinals.SINGLE_DOWN;

                case "DoubleDown":
                    return ShareGlucoseSlopeOrdinals.DOUBLE_DOWN;

                case "NOT COMPUTABLE":
                    return ShareGlucoseSlopeOrdinals.NOT_COMPUTABLE;

                case "OUT OF RANGE":
                    return ShareGlucoseSlopeOrdinals.OUT_OF_RANGE;

                default:
                case "None":
                    return ShareGlucoseSlopeOrdinals.NONE;
            }
        }
    }
}