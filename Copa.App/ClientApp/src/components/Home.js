import React, { Component } from 'react';
import { Redirect } from 'react-router-dom';

export class Home extends Component {

    constructor(props) {
        super(props);
        this.state = {
            currentCount: 0, equipes: [], iniciarCopa: false, selecionadas:[]
        };
        this.incrementCounter = this.incrementCounter.bind(this);
        this.getEquipes = this.getEquipes.bind(this);
        this.startCopa = this.startCopa.bind(this);
    }

    componentDidMount() {
        this.getEquipes();
        console.log("loaded!");
    }

    incrementCounter(e,el) {

        var count = this.state.currentCount;
        var _selecionadas = this.state.selecionadas;
        if (e.target.checked) {
            count++;
            _selecionadas.push(el);
        }
        else {
            count--;
            _selecionadas.pop(el);
        }

        this.setState({
            currentCount: count,
            equipes: this.state.equipes,
            iniciarCopa: false,
            selecionadas: _selecionadas
        });
    }

    getEquipes() {
        fetch("Equipe", {
            method: 'Get'
        }).then(response => response.json())
            .then(data => {
                this.setState({
                    currentCount: this.state.currentCount,
                    equipes: data,
                    iniciarCopa: false,
                    selecionadas: this.state.selecionadas
                });
            });
    }

    startCopa() {
        if (this.state.currentCount == 8) {
           
            this.setState({
                currentCount: this.state.currentCount,
                equipes: this.state.equipes,
                iniciarCopa: true,
                selecionadas: this.state.selecionadas
            });
        }
        else
            alert('Selecione 8 times para a copa');
    }

    static displayName = Home.name;

    render() {
        if (this.state.iniciarCopa == true) 
            return (<Redirect to={{
                pathname: "/copa",
                state: { equipes: this.state.selecionadas }
            }} />);
        else
            return (
                <div>
                    <div className="jumbotron">
                        <div className="container">
                            <h2 className="display-3" style={{ alignContent: "center" }}>Copa</h2>
                            <h3>Fase de selecao.</h3>
                            <h4>Selecione 8 equipes que voce deseja que participe da copeticao e em seguida clique em gerar copa.</h4>
                        </div>
                        <div className="d-flex justify-content-between">
                            <div style={{ float: "left" }}>
                                <p>Equipes selecionadas: {this.state.currentCount}</p>
                            </div>
                            <div style={{ float: "right" }}>
                                <button className="btn btn-sm" style={{ backgroundColor: "#8c8c8c" }} onClick={this.startCopa}>Gerar Copa</button>
                            </div>
                        </div>
                    </div>
                    <div className="container">
                        <div className="row">
                            {
                                this.state.equipes.map((el, i) => {
                                    return (
                                        <div className="col-md-4" key={el.Id}>
                                            <div className="card mb-4 shadow-sm">
                                                <div className="card-header">
                                                    <input type="checkbox" id={el.Id} name="checkEquipe" value={ el.Id } onChange={e => this.incrementCounter(e,el)} />
                                                </div>
                                                <div className="card-body">
                                                    <p className="text">
                                                        {el.Nome}
                                                    </p>
                                                </div>
                                            </div>
                                        </div>
                                    )
                                })
                            }
                        </div>
                    </div>
                </div>
            );
    }
}
