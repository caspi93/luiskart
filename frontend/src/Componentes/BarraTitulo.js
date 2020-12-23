import React, { Component } from 'react';
import './BarraTitulo.css';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';

class BarraTitulo extends Component {
    render() {
        return (
            <nav className="BarraTitulo navbar navbar-expand-lg navbar-light">
                <div className="collapse navbar-collapse" id="navbarSupportedContent">
                    <ul className="navbar-nav mr-auto">
                        <li className="nav-item">{this.props.titulo}</li>
                    </ul>
                    <form className="form-inline">
                        <button className="btn btn-primary my-2 my-sm-0" type="button" onClick={this.props.onClickNuevo}><FontAwesomeIcon icon="plus" /> Nuevo</button>
                    </form>
                </div>
            </nav>
        )
    }
}

export default BarraTitulo;