import React, { Component } from 'react';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';

import imagen from '../Imagenes/Sesshomaru.png';
import SeleccionarPersonaje from './SeleccionarPersonaje';

class AgregarDibujo extends Component {
    constructor(props) {
        super(props);
        this.onClickCambiarArchivo = this.onClickCambiarArchivo.bind(this);
        this.onClickSelecPersonaje = this.onClickSelecPersonaje.bind(this);
        this.onClickCerrarSelecPersonaje = this.onClickCerrarSelecPersonaje.bind(this);
        this.state = {
            archivo: null,
            imagenCargada: null,
            showModalSelecPersonaje: false
        }
    }

    onClickCambiarArchivo(evento) {
        evento.stopPropagation();
        evento.preventDefault();
        var archivo = evento.target.files[0];
        
        let reader = new FileReader();
        reader.readAsDataURL(archivo);
        reader.onload = () => {
            this.setState({ archivo, imagenCargada: reader.result });
        }
    }

    onClickSelecPersonaje() {
        this.setState({
            showModalSelecPersonaje: true
        })
    }

    onClickCerrarSelecPersonaje() {
        this.setState({
            showModalSelecPersonaje: false
        })
    }

    render() {
        return (
            <div>
                <div className="row">
                    <div className="col col-md-6">
                        <button className="btn btn-success my-2 my-sm-0" onClick={this.onClickSelecPersonaje} title="Agregar Personaje"><FontAwesomeIcon icon="plus-circle" />Agregar Personaje</button>
                    </div>
                </div>
                <div className="row">
                    <div className="col col-md-6 seccion-master">
                        <table className="table table-sm table-dark">
                            <thead>
                                <tr>
                                    <th scope="col">#</th>
                                    <th scope="col">Anime</th>
                                    <th scope="col">Personaje</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <th scope="row">1</th>
                                    <td>Mark</td>
                                    <td>Otto</td>
                                    <td><button className="btn btn-danger my-2 my-sm-0" title="Quitar"><FontAwesomeIcon icon="minus-circle" /></button></td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                    <div className="col col-md-6 seccion-master">
                        <div className="card">
                            <img className="card-img-top" src={this.state.imagenCargada} alt="archivo del dibujo" />
                            <div className="card-body text-center">
                                <input
                                    type="file"
                                    ref={(ref) => this.inputImagen = ref}
                                    style={{ display: 'none' }}
                                    onChange={this.onClickCambiarArchivo}
                                />
                                <button className="btn btn-primary my-2 my-sm-0" onClick={() => { this.inputImagen.click() }}>
                                    <FontAwesomeIcon icon="arrow-circle-up" /> Seleccionar Imagen
                                </button>
                            </div>
                        </div>
                    </div>
                </div>
                <SeleccionarPersonaje animes={this.props.animes} show={this.state.showModalSelecPersonaje} onClickCerrar={this.onClickCerrarSelecPersonaje} />
            </div>
        )
    }
}

export default AgregarDibujo;