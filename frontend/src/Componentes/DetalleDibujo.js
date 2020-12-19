import React, { Component } from 'react';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';

class DetalleDibujo extends Component {
    render() {
        const dibujo = this.props.dibujo;
        console.log("Render Detalle Detalle Dibujo", dibujo.Id);
        const personajes = dibujo.Personajes.map((personaje, i) => {
            return <li key={personaje.Id} className="list-group-item"><a href="#" className="card-link">{personaje.Nombre} ({personaje.Anime.Nombre})</a></li>;
        });

        const imagen = "data:image/png;base64," + dibujo.Imagen;

        return (
            <div>
                <div className="card mb-1 mt-2">
                    <div className="row no-gutters">
                        <div className="col-lg-8">
                            <img src={imagen} className="card-img" alt="..." />
                        </div>
                        <div className="col-lg-4">
                            <div className="card-body">
                                <div className="text-right">
                                    <button className="btn btn-primary my-2 my-sm-0" type="submit" title="Descargar"><FontAwesomeIcon icon="download" /></button>
                                </div>
                                <p className="card-text">
                                    <small>Fecha Creación: {dibujo.FechaCreacion}</small><br />
                                    <small>Fecha Ingreso:  {dibujo.FechaIngreso}</small>
                                </p>
                            </div>
                            <ul className="list-group list-group-flush">
                                {personajes}
                            </ul>
                        </div>
                    </div>
                </div>
            </div>
        )
    }
}

export default DetalleDibujo;