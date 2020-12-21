import React, { Component } from 'react';
import './MasterDibujo.css';
import BarraTitulo from './BarraTitulo';
import ElementoAnime from './ElementoAnime';
import DetalleAnime from './DetalleAnime';

class MasterAnime extends Component {
    constructor(props) {
        super(props);
        this.handleClick = this.handleClick.bind(this);
        this.state = {
            animeSeleccionado: null
        }

    }

    static getDerivedStateFromProps(props, state) {
        let animeSeleccionado = state.animeSeleccionado;
        if (animeSeleccionado == null && props.animes.length > 0) {
            animeSeleccionado = props.animes[0];
        }

        return {
            animeSeleccionado
        }
    }

    handleClick(anime) {
        this.setState({
            animeSeleccionado: anime
        });
    }

    render() {
        const animes = this.props.animes.map((anime, i) => { return <ElementoAnime key={anime.Id} anime={anime} onClick={this.handleClick} /> });
        let detalleAnime;
        if (this.state.animeSeleccionado != null) {
            detalleAnime = <DetalleAnime anime={this.state.animeSeleccionado} />;
        } else {
            detalleAnime = <div></div>
        }

        return (
            <div className="MasterDibujo bg-light">
                <BarraTitulo titulo="Animes" />
                <div className="container-fluid">
                    <div className="row">
                        <div className="col col-md-4 seccion-master" id="lista-dibujos">
                            <div className="row row-cols-1 row-cols-md-1">
                                <div className="col mb-1 mt-1">
                                    {animes}
                                </div>
                            </div>
                        </div>
                        <div className="col col-md-8 seccion-master" >
                            {detalleAnime}
                        </div>
                    </div>
                </div>
            </div>
        )
    }
}
export default MasterAnime;