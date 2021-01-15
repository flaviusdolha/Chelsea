import React, { useState, useContext } from 'react';
import { DashboardContext } from "./Dashboard";

function Project({ withCards })
{
    const dashboardContext = useContext(DashboardContext)
    
    return (
        <div className="flex flex-col">
            <div className="flex flex-wrap -mx-3 -my-3">
                {withCards.map(card => <ProjectCard key={card.card.id} card={card} />)}
            </div>
            <div className="mt-8 p-2 rounded-lg border bg-blue-600 hover:bg-blue-400 md:w-32 cursor-pointer focus:shadow-inner" onClick={() => dashboardContext.showModal("NEW_CARD")}>
                <div className="flex justify-around content-around">
                    <button className="text-white text-medium font-semibold">New Card</button>
                </div>
            </div>
        </div>
    );
}

function ProjectCard({ card })
{
    const [tickets, setTickets] = useState(card.tickets);
    
    return (
        <div className="h-auto w-full md:w-1/2 lg:w-1/3 xl:w-1/4 p-3">
            <div className="border rounded-lg bg-gray-100">
                <div className="w-full flex justify-around border-b-2 cursor-pointer hover:bg-gray-50 hover:rounded-t-lg">
                    <h1 className="p-4 text-lg font-medium uppercase">{ card.card.name }</h1>
                </div>
                {tickets.map(ticket => {
                    return (
                        <div key={ticket.id} className="w-auto flex rounded-lg ml-2 mr-2 mt-2 mb-2 bg-white border hover:border-gray-300 active:shadow-inner cursor-pointer">
                            <div className="h-auto w-1 bg-blue-500 rounded-l-lg" />
                            <div className="flex flex-wrap">
                                <h1 className="p-4 text-sm">{ticket.title}</h1>
                            </div>
                        </div>
                    )
                })}
                <div className="border-t-2">
                    <div className="w-auto flex rounded-lg ml-2 mr-2 mt-2 mb-2 bg-white border hover:border-gray-300 active:shadow-inner cursor-pointer">
                        <h1 className="p-4 text-sm"><i className="fas fa-plus text-sm mr-1" /> Add ticket</h1>
                    </div>
                </div>
            </div>
        </div>
    );
}

export default Project;