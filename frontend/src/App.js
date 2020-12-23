import './App.css';
import { Component } from 'react';
import { library } from '@fortawesome/fontawesome-svg-core';
import { fas } from '@fortawesome/free-solid-svg-icons';

import Navegacion from './Componentes/Navegacion';
import MasterDibujo from './Componentes/MasterDibujo';
import MasterAnime from './Componentes/MasterAnime';
import Footer from './Componentes/Footer';

library.add(fas);

class App extends Component {
    constructor() {
        super();
        this.handleClickNav = this.handleClickNav.bind(this);
        this.state = {
            vistaSeleccionada: "master_dibujo",
            dibujos: [],
            animes:[]
        }
    }

    componentDidMount() {
        fetch('https://localhost:44391/api/dibujos/')
            .then((response) => {
                return response.json()
            })
            .then((dibujos) => {
                this.setState({ dibujos: dibujos })
            })

        fetch('https://localhost:44391/api/animes/').
            then((response) => {
                return response.json()
            })
            .then((animes) => {
                this.setState({ animes: animes })
            })
    }

    handleClickNav(vista) {
        this.setState({
            vistaSeleccionada: vista
        });
    }

    render() {
        let vista;
        if (this.state.vistaSeleccionada == "master_dibujo") {
            vista = <MasterDibujo dibujos={this.state.dibujos} animes={this.state.animes} />
        } else {
            vista = <MasterAnime animes={this.state.animes} />
        }

        return (
            <div className="App">
                <Navegacion vista={this.state.vistaSeleccionada} onClickVista={this.handleClickNav} /> 
                {vista}
                <Footer />
            </div>
        );
    }
}

export default App;
