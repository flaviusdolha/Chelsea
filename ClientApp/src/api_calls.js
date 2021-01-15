import axios from 'axios';

/*
*
* PROJECT
*
*/
export const getProjects = async () => {
    let projects = [];
    await fetch("https://chelsea.azurewebsites.net/api/projects")
        .then(data => data.json())
        .then(data => {
            data.map(project => projects.push(project));
        });
    return projects;
}

export const getOneProjectFull = async (id) => {
    let dat = null;
    await fetch("https://chelsea.azurewebsites.net/api/dashboard/project/" + id)
        .then(data => data.json())
        .then(data => {
            dat = data;
        });
    return dat;
}

export const postProject = async (ownerId, name) => {
    await axios.post("https://chelsea.azurewebsites.net/api/projects", { ownerId, name })
}

export const deleteProject = async (id) => {
    await axios.delete("https://chelsea.azurewebsites.net/api/projects/" + id)
}

/*
*
* CARD
*
*/
export const postCard = async (name, projectId) => {
    await axios.post("https://chelsea.azurewebsites.net/api/cards", { name, projectId })
}
