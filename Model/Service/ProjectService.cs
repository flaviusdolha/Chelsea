using System;
using System.Collections.Generic;
using Chelsea.Model.Domain;
using Chelsea.Model.Repository;

namespace Chelsea.Model.Service
{
    public class ProjectService
    {
        private readonly IRepository<Project> _projectRepository;

        public ProjectService(IRepository<Project> projectRepository)
        {
            _projectRepository = projectRepository;
        }

        /// <summary>
        /// Creates a Project and adds it to the Repository.
        /// </summary>
        public void AddProject(Dictionary<string, dynamic> options)
        {
            var id = _projectRepository.GetNextId();
            if (id == 0) throw new Exception("Internal server error when trying to add a Project.");
            var project = new Project(id, Int32.Parse(options["ownerId"].ToString()), options["name"].ToString());
            _projectRepository.Create(project);
        }

        /// <summary>
        /// Gets all Projects from the Repository.
        /// </summary>
        /// <returns>A list of Projects.</returns>
        public List<Project> GetAllProjects() => _projectRepository.GetAll();
        
        /// <summary>
        /// Gets all Projects from the Repository that are of one owners id.
        /// </summary>
        /// <param name="ownerId">An integer representing the Id of the owner to be retrieved from.</param>
        /// <returns>A list of Projects.</returns>
        public List<Project> GetAllProjects(int ownerId) => _projectRepository.GetAllOnParent(ownerId);

        /// <summary>
        /// Gets one Project with a specified Id.
        /// </summary>
        /// <param name="projectId">An integer representing the Id of the Project to be retrieved.</param>
        /// <returns>A Project representing the Project that was requested.</returns>
        public Project GetProjectWithId(int projectId) => _projectRepository.FindById(projectId);

        /// <summary>
        /// Modifies one Project
        /// </summary>
        /// <param name="project">Project to be modified.</param>
        public void ModifyProject(Project project) => _projectRepository.Update(project);

        /// <summary>
        /// Removes a Project from the Repository.
        /// </summary>
        /// <param name="projectId">An integer representing the Id of the Project to be removed.</param>
        public void RemoveProject(int projectId) => _projectRepository.Delete(projectId);
    }
}