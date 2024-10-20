import React from 'react';
import './Header.css';

const Header: React.FC = () => {
    return (
        <header className='header'>
            {/* Left */}
            <div className='header-left'>
                <button className='menu-button'>☰</button>
                <a href="/" className="home-button">Home</a>
            </div>
            {/* Mid */}
            <div className="header-center">
                <input
                    type="text"
                    className="search-bar"
                    placeholder="Search..."
                />
            </div>
            {/* Right */}
            <div className="header-right">
                <button className="profile-button">Profile</button>
            </div>
        </header>
    );
};

export default Header;