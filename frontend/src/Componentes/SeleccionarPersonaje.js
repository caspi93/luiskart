import React, { Component } from 'react';
import Modal from 'react-bootstrap/Modal';
import Button from 'react-bootstrap/Button';
import Form from 'react-bootstrap/Form';

class SeleccionarPersonaje extends Component {
    constructor(props) {
        super(props);
        this.onChangeAnime = this.onChangeAnime.bind(this);
        this.state = {
            animeSeleccionado: null
        }
    }

    onChangeAnime(evento) {
        const posicion = evento.target.value;
        const anime = this.props.animes[posicion];
        console.log("Anime: ", anime);
        this.setState({
            animeSeleccionado: anime
        })
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

    render() {
        const animes = this.props.animes.map((anime, i) => { return <option value={i}>{anime.Nombre}</option> });
        let personajes;
        if (this.state.animeSeleccionado != null) {
            personajes = this.state.animeSeleccionado.Personajes.map((personaje, i) => {
                return <option value={personaje.Id}>{personaje.Nombre}</option>
            });
        } else {
            personajes = []
        }

        return (
            <Modal show={this.props.show} onHide={this.props.onClickCerrar}>
                <Modal.Header closeButton>
                    <Modal.Title>Seleccionar Personaje</Modal.Title>
                </Modal.Header>
                <Modal.Body>
                    <Form>
                        <Form.Group controlId="exampleForm.SelectCustom">
                            <Form.Label>Seleccione un anime</Form.Label>
                            <Form.Control as="select" custom onChange={this.onChangeAnime}>
                                {animes}                             
                            </Form.Control>
                        </Form.Group>
                        <Form.Group controlId="exampleForm.SelectCustom">
                            <Form.Label>Seleccione un personaje</Form.Label>
                            <Form.Control as="select" custom>
                                {personajes}
                            </Form.Control>
                        </Form.Group>
                    </Form>
                </Modal.Body>
                <Modal.Footer>
                    <Button variant="secondary" onClick={this.props.onClickCerrar}>
                        Cerrar
                     </Button>
                    <Button variant="primary" onClick={this.props.onClickCerrar}>
                        Seleccionar
                    </Button>
                </Modal.Footer>
            </Modal>
        )
    }
}
export default SeleccionarPersonaje;
