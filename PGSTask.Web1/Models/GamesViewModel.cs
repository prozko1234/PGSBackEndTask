using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PGSTask.Web1.Models
{
    /// <summary>
    /// View model for showing data on view
    /// </summary>
    public class GamesViewModel
    {
        public List<Game> Games { get; set; }
        public Game GameView { get; set; }
    }
}
