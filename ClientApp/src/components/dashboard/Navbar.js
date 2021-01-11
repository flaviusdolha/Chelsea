import React from 'react';

function Navbar() {
    return (
        <div className="bg-blue-600 h-14 flex flex-wrap content-center p-6 shadow-lg justify-between">
            <div className="flex flex-wrap content-center">
                <p className="text-white text-lg font-semibold">Chelsea</p>
            </div>
            <div className="flex flex-wrap content-center group">
                <div className="flex flex-wrap content-center">
                    <i class="fas fa-caret-down text-sm fill text-white group-hover:text-gray-300"></i>
                </div>
                <div className="flex flex-wrap content-center ml-2">
                    <p className="text-white text-sm group-hover:text-gray-300">Flavius Dolha</p>
                </div>
                <i class="fas fa-user-circle ml-4 text-2xl fill text-white group-hover:text-gray-300"></i>
            </div>
        </div>
    );
}

export default Navbar;