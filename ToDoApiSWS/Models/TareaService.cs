using MongoDB.Driver;

namespace ToDoApiSWS.Models {
    public class TareaService {
        private readonly IMongoCollection<Tarea> _tareas;

        public TareaService(ITareaDatabaseSettings settings) {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _tareas = database.GetCollection<Tarea>(settings.TareasCollectionName);
        }

        public async Task<List<Tarea>> GetAllAsync() {
            return await _tareas.Find(s => true).ToListAsync();
        }

        public async Task<Tarea> GetByIdAsync(string id) {
            return await _tareas.Find<Tarea>(c => c.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Tarea> CreateAsync(Tarea tarea) {
            await _tareas.InsertOneAsync(tarea);
            return tarea;
        }

        public async Task UpdateAsync(string id, Tarea tarea) {
            await _tareas.ReplaceOneAsync(c => c.Id == id, tarea);
        }

        public async Task DeleteAsync(string id) {
            await _tareas.DeleteOneAsync(c => c.Id == id);
        }
    }
}
