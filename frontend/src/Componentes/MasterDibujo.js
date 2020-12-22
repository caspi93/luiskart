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
        this.state = {
            dibujoSeleccionado: null
        }
    }

    static getDerivedStateFromProps(props, state) {
        let dibujoSeleccionado = state.dibujoSeleccionado;
        if (dibujoSeleccionado == null && props.dibujos.length > 0) {
            dibujoSeleccionado = props.dibujos[0];
        }

        return {
            dibujoSeleccionado
        }
    }

    handleClick(dibujo) {
        this.setState({
            dibujoSeleccionado: dibujo
        });
    }

    render() {
        const dibujos = this.props.dibujos.map((dibujo, i) => { return <ElementoDibujo key={dibujo.Id} dibujo={dibujo} onClick={this.handleClick} /> });
        let detalleDibujo;
        if (this.state.dibujoSeleccionado != null) {
            detalleDibujo = <DetalleDibujo dibujo={this.state.dibujoSeleccionado} />;
        } else {
            detalleDibujo = <div></div>
        }

        return (
            <div className="MasterDibujo bg-light">
                <BarraTitulo titulo="Dibujos" />
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
                            {/*detalleDibujo*/}
                            <AgregarDibujo />
                        </div>
                    </div>
                </div>
            </div>
        )
    }
}
export default MasterDibujo;