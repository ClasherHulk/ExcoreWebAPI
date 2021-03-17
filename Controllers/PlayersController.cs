using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiCore.Models;

namespace WebApiCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        static List<Player> listPlayers = new List<Player>
        {
            new Player{PId=1,PName="Jofra Archer",PDOB=DateTime.Parse("12/12/1990"),PTeam="Englnad"},
             new Player{PId=2,PName="Mithali Raj",PDOB=DateTime.Parse("02/02/1991"),PTeam="India"},
              new Player{PId=3,PName="Mark Wood",PDOB=DateTime.Parse("07/08/1989"),PTeam="England"}

        };
        [HttpGet]
        public IEnumerable<Player> GetPlayers()
        {
            return listPlayers;
        }
        [HttpGet("id")]
        public IEnumerable<Player> Get(int id)
        {
            Player name = null;
            foreach (Player n in listPlayers)
            {
                if (listPlayers.IndexOf(n) == id)
                {
                    name = n;
                    break;
                }
            }
            return listPlayers;
        }
        [HttpPost]
        public ActionResult Post([FromBody] Player value)
        {
            listPlayers.Add(value);
            return NoContent();

        }
       
        

        [HttpPut("{id}")]
        public ActionResult PutPlayers(int id, [FromBody] Player value)
        {
            bool flag = false;

            foreach (Player n in listPlayers)
            {
                if (listPlayers.IndexOf(n) == id)
                {
                    flag = true;
                    break;
                }
            }
            if (flag)
            {
                listPlayers[id] = value;

            }
            return NoContent();

        }
        [HttpDelete("{id}")]
        public ActionResult DeletePlayer(int id)
        {
            bool flag = false;

            foreach (Player n in listPlayers)
            {
                if (n.PId == id)
                {
                    flag = true;


                }
            }
            if (flag)
            {
                listPlayers.RemoveAt(id);
                return NoContent();
            }
            else
            {
                return NotFound();
            }


        }

    }
}

