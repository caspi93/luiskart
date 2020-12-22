import React, { Component } from 'react';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';

import imagen from '../Imagenes/Sesshomaru.png';

class AgregarDibujo extends Component {
    constructor(props) {
        super(props);
        this.onClickCambiarArchivo = this.onClickCambiarArchivo.bind(this);
        this.state = {
            archivo:  null
        }
    }

    onClickCambiarArchivo(evento) {
        evento.stopPropagation();
        evento.preventDefault();
        var archivo = evento.target.files[0];
        console.log(archivo);
        this.setState({ archivo });
    }

    render() {
        return (
            <div>
                <div className="row">
                    <div className="col col-md-6">
                        <button className="btn btn-success my-2 my-sm-0" title="Agregar Personaje"><FontAwesomeIcon icon="plus-circle" />Agregar Personaje</button>
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
                            <img className="card-img-top" src={imagen} alt="archivo del dibujo" />
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
            </div>
        )
    }
}

export default AgregarDibujo;