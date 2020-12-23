import React, { Component } from 'react';

class ElementoDibujo extends Component {
    constructor(props) {
        super(props);
    }

    render() {
        const dibujo = this.props.dibujo;
        const primerPersonaje = dibujo.Personajes[0];
        const imagen = "data:image/png;base64," + dibujo.Imagen;

        return (
            <div onClick={() => this.props.onClick(dibujo)}>
                <div className="card mb-1">
                    <div className="row no-gutters">
                        <div className="col-md-4">
                            <img src={imagen} className="card-img" alt="..." />
                        </div>
                        <div className="col-md-8">
                            <div className="card-body">
                                <h5 className="card-title">{primerPersonaje.Nombre}</h5>
                                <h6 className="card-subtitle mb-2 text-muted">{primerPersonaje.Anime.Nombre}</h6>
                                <p className="card-text"><small className="text-muted">Fecha Creación: {dibujo.FechaCreacion}</small><br />
                                    <small className="text-muted">Fecha Ingreso: {dibujo.FechaIngreso}</small></p>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        )
    }
}

export default ElementoDibujo;