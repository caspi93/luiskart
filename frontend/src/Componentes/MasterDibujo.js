import React, { Component } from 'react';
import './MasterDibujo.css';
import BarraTitulo from './BarraTitulo';
import ElementoDibujo from './ElementoDibujo';
import DetalleDibujo from './DetalleDibujo';
import AgregarDibujo from './AgregarDibujo';

class MasterDibujo extends Component {
    constructor(props) {
        super(props);
        this.handleClick = this.handleClick.bind(this);
        this.onClickNuevo = this.onClickNuevo.bind(this);
        this.onClickAtras = this.onClickAtras.bind(this);

        this.state = {
            dibujoSeleccionado: null,
            vistaSeleccionada: "detalle_dibujo"
        }
    }

    static getDerivedStateFromProps(props, state) {
        let dibujoSeleccionado = state.dibujoSeleccionado;
        let vistaSeleccionada = state.vistaSeleccionada;

        if (dibujoSeleccionado == null && props.dibujos.length > 0) {
            dibujoSeleccionado = props.dibujos[0];
            vistaSeleccionada = "detalle_dibujo";
        }
        else if (vistaSeleccionada == "detalle_dibujo" && dibujoSeleccionado == null) {
            vistaSeleccionada = "agregar_dibujo";
        }

        return {
            dibujoSeleccionado,
            vistaSeleccionada
        }
    }

    handleClick(dibujo) {
        this.setState({
            dibujoSeleccionado: dibujo
        });
    }

    onClickNuevo() {
        this.setState({
            vistaSeleccionada: "agregar_dibujo"
        });
    }

    onClickAtras() {
        this.setState({
            vistaSeleccionada: "detalle_dibujo"
        });
    }

    render() {
        const dibujos = this.props.dibujos.map((dibujo, i) => { return <ElementoDibujo key={dibujo.Id} dibujo={dibujo} onClick={this.handleClick} /> });
        let vista;
        if (this.state.dibujoSeleccionado != null && this.state.vistaSeleccionada == "detalle_dibujo") {
            vista = <DetalleDibujo dibujo={this.state.dibujoSeleccionado} />;
        } else {
            const puedeIrAtras = this.state.dibujoSeleccionado != null;
            vista = <AgregarDibujo animes={this.props.animes} onClickAtras={this.onClickAtras} puedeIrAtras={puedeIrAtras} />
        }

        return (
            <div className="MasterDibujo bg-light">
                <BarraTitulo titulo="Dibujos" onClickNuevo={this.onClickNuevo} />
                <div className="container-fluid">
                    <div className="row">
                        <div className="col col-md-4 seccion-master" id="lista-dibujos">
                            <div className="row row-cols-1 row-cols-md-1">
                                <div className="col mb-1 mt-1">
                                    {dibujos}
                                </div>
                            </div>
                        </div>
                        <div className="col col-md-8 seccion-master" >
                            { vista}
                        </div>
                    </div>
                </div>
            </div>
        )
    }
}
export default MasterDibujo;