import React, { Component } from 'react';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';

import placeholder from '../Imagenes/default-placeholder.png';
import SeleccionarPersonaje from './SeleccionarPersonaje';

class AgregarDibujo extends Component {
    constructor(props) {
        super(props);
        this.onClickCambiarArchivo = this.onClickCambiarArchivo.bind(this);
        this.onClickSelecPersonaje = this.onClickSelecPersonaje.bind(this);
        this.onClickCerrarSelecPersonaje = this.onClickCerrarSelecPersonaje.bind(this);
        this.onSeleccionarPersonaje = this.onSeleccionarPersonaje.bind(this);

        this.state = {
            archivo: null,
            imagenCargada: null,
            showModalSelecPersonaje: false,
            personajes: []
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

    onSeleccionarPersonaje(personaje) {
        this.setState((state) => {
            return {
                personajes: state.personajes.concat([personaje]),
                showModalSelecPersonaje: false
            }
        });
    }

    render() {
        const personajes = this.state.personajes.map((personaje, i) => {
            return <tr>
                <th scope="row">{i + 1}</th>
                <td>{personaje.Anime.Nombre}</td>
                <td>{personaje.Nombre}</td>
                <td><button className="btn btn-danger my-2 my-sm-0" title="Quitar"><FontAwesomeIcon icon="minus-circle" /></button></td>
            </tr>
        })

        let cargarImagen;
        if (this.state.imagenCargada != null) {
            cargarImagen = <img className="card-img-top" src={this.state.imagenCargada} alt="archivo del dibujo" />
        } else {
            cargarImagen = <img className="card-img-top" src={placeholder} alt="archivo del dibujo" />
        }

        return (
            <div>
                <div className="row">
                    <div className="col col-md-6">
                        <button className="btn btn-light my-2 my-sm-0" title="Atrás" onClick={this.props.onClickAtras} disabled={!this.props.puedeIrAtras}><FontAwesomeIcon icon="arrow-circle-left" /></button>
                        <button className="btn btn-success my-2 my-sm-0" onClick={this.onClickSelecPersonaje}>
                            <FontAwesomeIcon icon="plus-circle" /> Agregar Personaje
                        </button>
                    </div>
                </div>
                <div className="row">
                    <div className="col col-md-6 seccion-master text-center">
                        <table className="table table-sm table-dark">
                            <thead>
                                <tr>
                                    <th scope="col">#</th>
                                    <th scope="col">Anime</th>
                                    <th scope="col">Personaje</th>
                                </tr>
                            </thead>
                            <tbody>
                                {personajes}
                            </tbody>
                        </table>
                        <button className="btn btn-success my-2 my-sm-0">Guardar</button>
                    </div>
                    <div className="col col-md-6 seccion-master">
                        <div className="card">
                            {cargarImagen}
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
                <SeleccionarPersonaje
                    animes={this.props.animes}
                    show={this.state.showModalSelecPersonaje}
                    onClickCerrar={this.onClickCerrarSelecPersonaje}
                    onSeleccionar={this.onSeleccionarPersonaje} />
            </div>
        )
    }
}

export default AgregarDibujo;