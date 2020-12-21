import React, { Component } from 'react';

class ElementoAnime extends Component {

    constructor(props) {
        super(props);
    }

    render() {
        const anime = this.props.anime;
        const portada = "data:image/png;base64," + anime.Portada;

        let primerPersonaje;
        if (anime.Personajes.length > 0) {
            primerPersonaje = anime.Personajes[0].Nombre;
        } else {
            primerPersonaje = "--";
        }

        return (
            <div onClick={() => this.props.onClick(anime)}>
                <div className="card mb-1">
                    <div className="row no-gutters">
                        <div className="col-md-4">
                            <img src={portada} className="card-img" alt="..." />
                        </div>
                        <div className="col-md-8">
                            <div className="card-body">
                                <h5 className="card-title">{anime.Nombre}</h5>
                                <h6 className="card-subtitle mb-2 text-muted" >{primerPersonaje}</h6 >
                                <p className="card-text"><small className="text-muted">Fecha De Estreno: {anime.FechaEstreno}</small><br />
                                    <small className="text-muted">Género: {anime.Genero.Nombre}</small></p>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        )
    }
}

export default ElementoAnime;