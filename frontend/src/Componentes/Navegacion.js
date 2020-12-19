import React, { Component } from 'react';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';

class Navegacion extends Component {
    render() {
        return (
            <nav className="navbar navbar-expand-lg navbar-dark bg-dark">
                <a className="navbar-brand" href="#">Luiskart93</a>
                <button className="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                    <span className="navbar-toggler-icon"></span>
                </button>
                <div className="collapse navbar-collapse" id="navbarSupportedContent">
                    <ul className="navbar-nav mr-auto">
                        <li className="nav-item"><a href="" className="text-white nav-link">Dibujos</a></li>
                        <li className="nav-item"><a href="" className="text-white nav-link">Animes</a></li>
                    </ul>
                    <form className="form-inline">
                        <input className="form-control mr-sm-2" type="search" placeholder="Buscar dibujos o animes" aria-label="Search" />
                        <button className="btn btn-outline-light my-2 my-sm-0" type="submit"><FontAwesomeIcon icon="search" /></button>
                    </form>
                </div>
            </nav>
        )
    }
}
export default Navegacion;