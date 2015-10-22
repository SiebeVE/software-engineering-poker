using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerProject
{
  public class pokerModel
  {
    private int numberOfPLayers = 1;

    public int NumberOfPLayers
    {
      get
      {
        return numberOfPLayers;
      }
      set
      {
        numberOfPLayers = value;
      }
    }
  }
}
