using System.Collections.Generic;

namespace PlanningBoard.Model
{
    public interface IColorRepository
    {
        List<Color> List();
        int Add(Color column);
    }
}