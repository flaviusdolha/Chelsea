import React, { useState, useEffect } from 'react';
import ProjectsList from './ProjectsList';
import Project from './Project';
import Navbar from './Navbar';
import Modal from './Modal';
import NewProject from "./modals/NewProject";
import NewCard from "./modals/NewCard";
import { useHistory } from 'react-router-dom';
import { getProjects, getOneProjectFull, postProject, deleteProject, postCard } from '../../api_calls';

export const DashboardContext = React.createContext(null);

function Dashboard()
{
    const [title, setTitle] = useState("");
    const [projects, setProjects] = useState([]);
    const [loading, setLoading] = useState(true);
    const [selectedProject, setSelectedProject] = useState(null);
    const [showModal, setShowModal] = useState(false);
    const [modalBody, setModalBody] = useState(null);
    
    const history = useHistory();
    
    let dashboardUtils = {
        title,
        setTitle: (title) => setTitle(title),
        selectProject: async (projectId) => {
            await getOneProject(projectId);
        },
        showModal: (body) => {
            setModalBody(MODAL_TYPES[body]);
            setShowModal(true);
        },
        closeModal: () => setShowModal(false),
        addProject: async (name) => { await addProject(name); await downloadProjects(); setShowModal(false); },
        deleteProject: async (id) => { await deleteProject(id); await downloadProjects(); },
        addCard: async (name) => {
            await addCard(name, selectedProject);
            await downloadProjects();
            await getOneProject(selectedProject.project.id);
            setShowModal(false);
        }
    };
    
    // Downloads projects
    useEffect(() => {
        (async () => downloadProjects())()
    }, []);
    
    useEffect(() => {
        dashboardUtils = { ...dashboardUtils, title: title }
    }, [setTitle])

    useEffect(() => {
        if (!selectedProject) if (title !== "") setTitle("Choose project:");
    }, [selectedProject])
    
    const downloadProjects = async () => {
        const projects = await getProjects();
        setLoading(false);
        setTitle("Choose project:");
        setProjects(projects);
    }
    
    const getOneProject = async (projectId) => {
        let data = await getOneProjectFull(projectId);
        setTitle(data.project.name);
        setSelectedProject(data);
    }
    
    const addProject = async (name) => {
        const ownerId = 1;
        await postProject(ownerId, name);
    }
    
    const addCard = async (name, selectedProject) => {
        await postCard(name, selectedProject.project.id);
    }
    
    const getContent = () =>
    {
        if (loading) return <Loading />
        else {
            if (selectedProject) {
                return <Project withCards={selectedProject.cards} />
            }
            else return <ProjectsList projects={projects}/>
        }
    }
    
    const backButton = () =>
    {
        if (!loading)
        {
            return <p className="text-blue-400 text-md lg:text-sm mb-6 hover:text-blue-600 cursor-pointer" onClick={() => onBackButtonClick()}><i className="fas fa-chevron-left"/> Back</p>;
        }
    }
    
    const onBackButtonClick = () =>
    {
        if (selectedProject) setSelectedProject(null);
        else history.goBack();
    }
    
    return (
        <DashboardContext.Provider value={dashboardUtils} >
            <div className="bg-gray-100 h-screen">
                <Navbar />
                <div className="container bg-white h-auto mt-12 mx-auto rounded-lg shadow-sm px-16 pb-16 pt-8 cursor-default">
                    <div className="mb-8">
                        {backButton()}
                        <h1 className="text-3xl font-semibold">{title}</h1>
                    </div>
                    {getContent()}
                </div>
            </div>
            {showModal ? <Modal>{modalBody}</Modal> : null}
        </DashboardContext.Provider>
    );
}

function Loading()
{
    return (
        <div className="h-full w-full flex flex-wrap content-center justify-center">
            <i className="fas fa-circle-notch text-5xl animate-spin" />
        </div>
    );
}

const MODAL_TYPES = {
    "NEW_PROJECT": <NewProject />,
    "NEW_CARD": <NewCard />
}

export default Dashboard;