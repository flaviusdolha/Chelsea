import React from 'react';
import { Link } from 'react-router-dom';

function Home() {
    return (
        <div className="bg-blue-600 h-screen w-screen flex flex-wrap">
            <div className="mx-auto pt-36 w-full">
                <div className="flex justify-around">
                    <h1 className="text-5xl text-white font-bold pt-4 pb-2 cursor-default">Chelsea Project</h1>
                </div>
                <div className="flex justify-around">
                    <p className="text-xs text-white font-light pb-4 cursor-default">Chelsea is a Project Management System that makes you productive.</p>
                </div>
                <Link to="/dashboard">
                    <div className="flex justify-around">
                        <button className="text-xl text-white py-2 px-4 border rounded-lg hover:bg-white hover:text-blue-600 active:shadow-inner">Go to the Dashboard</button>
                    </div>
                </Link>
            </div>
            <div className="mx-auto flex justify-around mb-12 mt-auto">
                <p className="text-xs text-white font-light pt-32 cursor-default">Version: Pre-Alpha v1.0</p>
            </div>
        </div>
    );
}

export default Home;