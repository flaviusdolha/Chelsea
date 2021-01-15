import React, { useContext } from "react";
import { DashboardContext } from "../Dashboard";

function NewProject()
{
    const dashboardContext = useContext(DashboardContext)
    
    return (
        <React.Fragment>
            <div className="min-w-lg flex justify-between">
                <h2 className="font-semibold text-2xl">Create project</h2>
                <h2 className="font-semibold text-2xl cursor-pointer"><i className="fas fa-times hover:text-gray-500 focus:shadow-inner" onClick={() => dashboardContext.closeModal()}/></h2>
            </div>
            <label className="block mt-6">
                <span className="text-gray-700">Project name:</span>
                <input id="NEW_PROJECT__PROJECT_NAME" className="form-input mt-2 block lg:w-1/2 w-full p-2 border text-gray-700 rounded-lg focus:outline-none focus:border-gray-400" placeholder="e.g. Scaling Parakeet" />
            </label>
            <button className="text-md mt-8 mb-4 text-white bg-blue-600 py-2 px-4 border rounded-lg hover:bg-blue-500 active:shadow-inner" onClick={() => dashboardContext.addProject(document.getElementById("NEW_PROJECT__PROJECT_NAME").value)}>Add Project</button>
        </React.Fragment>
    )
}

export default NewProject;