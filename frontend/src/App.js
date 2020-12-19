import './App.css';
import { Component } from 'react';
import { library } from '@fortawesome/fontawesome-svg-core';
import { fas } from '@fortawesome/free-solid-svg-icons';

import Navegacion from './Componentes/Navegacion';
import MasterDibujo from './Componentes/MasterDibujo';
import Footer from './Componentes/Footer';

library.add(fas);

class App extends Component {
    constructor() {
        super();
        this.state = {
            dibujos: []
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
    }

    render() {
        return (
            <div className="App">
                <Navegacion />
                <MasterDibujo dibujos={this.state.dibujos} />
                <Footer />
            </div>
        );
    }
}

export default App;
