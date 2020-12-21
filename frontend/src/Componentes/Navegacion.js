import React, { Component } from 'react';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';

class Navegacion extends Component {
    render() {
        const vista = this.props.vista;
        const vistaDibujo = "master_dibujo";
        const vistaAnime = "master_anime";

        const claseItem = "nav-link";
        const claseItemActivo = "nav-link active";
        const claseDibujo = vista == vistaDibujo ? claseItemActivo : claseItem;
        const claseAnime = vista == vistaAnime ? claseItemActivo : claseItem;

        return (
            <nav className="navbar navbar-expand-lg navbar-dark bg-dark">
                <a className="navbar-brand" href="#">Luiskart93</a>
                <button className="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                    <span className="navbar-toggler-icon"></span>
                </button>
                <div className="collapse navbar-collapse" id="navbarSupportedContent">
                    <ul className="navbar-nav mr-auto">
                        <li className="nav-item"><a onClick={() => this.props.onClickVista(vistaDibujo)} href="#" className={claseDibujo}>Dibujos</a></li>
                        <li className="nav-item"><a onClick={() => this.props.onClickVista(vistaAnime)} href="#" className={claseAnime}>Animes</a></li>
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