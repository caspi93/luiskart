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
        this.state = {
            dibujos: [],
            animes:[]
        }
    }

    componentDidMount() {
        {/*fetch('https://localhost:44391/api/dibujos/')
            .then((response) => {
                return response.json()
            })
            .then((dibujos) => {
                this.setState({ dibujos: dibujos })
            })*/}

        fetch('https://localhost:44391/api/animes/').
            then((response) => {
                return response.json()
            })
            .then((animes) => {
                this.setState({ animes: animes })
            })
    }

    render() {
        return (
            <div className="App">
                <Navegacion />
                {/*<MasterDibujo dibujos={this.state.dibujos} /> */}
                <MasterAnime animes={this.state.animes} />
                <Footer />
            </div>
        );
    }
}

export default App;
