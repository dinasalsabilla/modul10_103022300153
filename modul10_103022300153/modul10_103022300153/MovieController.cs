using Microsoft.AspNetCore.Mvc;

namespace modul10_103022300153
{
    [Route("api/[controller]")]
    [ApiController]

    public class MovieController : ControllerBase
    {
        private static List<String> Stars1 = new List<String>
        {
            new string("Tim Robbins"),
            new string("Morgan Freeman"),
            new string("Bob Gunton"),
        };

        private static List<String> Stars2 = new List<String>
        {
            new string("Marlon Brando"),
            new string("Al Pacino"),
            new string("James Caan"),
        };

        private static List<String> Stars3 = new List<String>
        {
            new string("Christian Bale"),
            new string("Heath Ledger"),
            new string("Aaron Eckhart"),
        };

        private static List<Movie> movieList = new List<Movie>
        {
            new Movie ("The Shawshank Redemption", "Frank Darabont" , Stars1, 
                "A banker convicted of uxoricide forms a friendship over a quarter century with a hardened convict," +
                "while maintaining his innocence and trying to remain hopeful through simple compassion." ),
            new Movie ("The Godfather", "Francis Ford Coppola" , Stars2, 
                "The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son." ),
            new Movie ("The Dark Knight", "\r\nChristopher Nolan" , Stars3,
                "When a menace known as the Joker wreaks havoc and chaos" +
                "on the people of Gotham, Batman, James Gordon and Harvey Dent" +
                "must work together to put an end to the madness." ),
        };

        // GET api/mahasiswa
        [HttpGet]
        public ActionResult<IEnumerable<Movie>> Get()
        {
            return Ok(movieList);
        }

        // GET api/mahasiswa/{index}
        [HttpGet("{index}")]
        public ActionResult<Movie> Get(int index)
        {
            if (index < 0 || index >= movieList.Count)
            {
                return NotFound("Movie dengan index tersebut tidak ditemukan.");
            }
            return Ok(movieList[index]);
        }

        // POST api/mahasiswa
        [HttpPost]
        public ActionResult Post([FromBody] Movie movie)
        {
            if (movie == null)
            {
                return BadRequest("Data movie tidak valid.");
            }
            movieList.Add(movie);
            return CreatedAtAction(nameof(Get), new { index = movieList.Count - 1 }, movie);
        }

        // DELETE api/mahasiswa/{index}
        [HttpDelete("{index}")]
        public ActionResult Delete(int index)
        {
            if (index < 0 || index >= movieList.Count)
            {
                return NotFound("Movie dengan index tersebut tidak ditemukan.");
            }
            movieList.RemoveAt(index);
            return NoContent();
        }
    }
}
