using Microsoft.AspNetCore.Mvc;
using CigaretteTrackerAPI.Models;
using System.Threading.Tasks;
using Google.Cloud.Firestore;

namespace CigaretteTrackerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CigaretteController : ControllerBase
    {
        private readonly FirestoreDb _firestoreDb;

        public CigaretteController()
        {
            _firestoreDb = FirestoreDb.Create("cigarettetracker-56877");
        }

        [HttpPost]
        public async Task<IActionResult> LogCigarette([FromBody] CigaretteLog log)
        {
            var collection = _firestoreDb.Collection("cigaretteLogs");
            log.Id = Guid.NewGuid().ToString();
            await collection.Document(log.Id).SetAsync(log);
            return Ok(log);
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetLogs(string userId)
        {
            var collection = _firestoreDb.Collection("cigaretteLogs");
            var snapshot = await collection.WhereEqualTo("UserId", userId).GetSnapshotAsync();
            var logs = snapshot.Documents.Select(doc => doc.ConvertTo<CigaretteLog>()).ToList();
            return Ok(logs);
        }
    }
}
