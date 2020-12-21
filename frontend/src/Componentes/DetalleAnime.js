import React, { Component } from 'react';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';

class DetalleAnime extends Component {
    render() {
        const anime = this.props.anime;
        const personajes = anime.Personajes.map((personaje, i) => {
            return <li key={personaje.Id} className="list-group-item"><a href="#" className="card-link">{personaje.Nombre}</a></li>;
        });

        const portada = "data:image/png;base64," + anime.Portada;
        return (
            <div>
                <div className="card mb-1 mt-2">
                    <div className="row no-gutters">
                        <div className="col-lg-8">
                            <img src={portada} className="card-img" alt="..." />
                        </div>
                        <div className="col-lg-4">
                            <div className="card-body">
                                <p className="card-text">
                                    <small>Fecha Estreno: {anime.FechaEstreno}</small><br />
                                    <small>Género:  {anime.Genero.Nombre}</small>
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

export default DetalleAnime;