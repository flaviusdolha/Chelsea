import React, { useContext } from "react";
import { DashboardContext } from "./Dashboard";

function ProjectsList({projects})
{
    const dashboardContext = useContext(DashboardContext)
    
    return (
        <div>
            {projects.map(project => <ProjectTab key={project.id} project={project} />)}
            <div className="h-16 w-auto min-w-64 border rounded-lg mt-2 mb-2 flex flex-wrap content-center hover:border-gray-400 cursor-pointer" onClick={() => dashboardContext.showModal("NEW_PROJECT")}>
                <h3 className="text-md ml-4 font-semibold"><i className="fas fa-plus text-sm mr-1"></i> New Project</h3>
            </div>
        </div>
    )
}

function ProjectTab({project})
{
    const dashboardContext = useContext(DashboardContext)
    
    return (
        <div key={project.id} className="group h-16 w-auto min-w-64 border rounded-lg mt-2 mb-2 flex flex-wrap content-center justify-between hover:border-gray-400 active:shadow-inner cursor-pointer">
            <div className="w-5/6 h-full flex flex-wrap content-center" onClick={() => dashboardContext.selectProject(project.id)}>
                <h3 className="text-xl ml-4">{project.name}</h3>
            </div>
            <div className="flex flex-wrap content-center">
                <i className="fas fa-trash-alt text-xl mr-4 group-hover:text-black text-white hover:text-gray-600" onClick={() => dashboardContext.deleteProject(project.id)} />
            </div>
        </div>
    )
}

export default ProjectsList;