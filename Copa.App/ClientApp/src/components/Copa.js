import React, { Component } from 'react';

export class Copa extends Component {
    static displayName = Copa.name;

    constructor(props) {
        super(props);
        this.state = { equipes: props.location.state.equipes, vencedores: [] };
        this.getVencedores = this.getVencedores.bind(this);
    }

    componentDidMount() {
        this.getVencedores();
    }

    getVencedores() {
        console.log(this.state.equipes);
        fetch('Copa', {
            method: 'POST',
            body: JSON.stringify(this.state.equipes),
            headers: { 'Content-Type': 'application/json' }
        }).then(response => response.json())
            .then(data => {
                this.setState({
                    equipes: this.state.equipes,
                    vencedores:data
                });
            });
    }

    render() {
        return (
            <div>
                <div className="jumbotron">
                    <div className="container">
                        <h2 className="display-3" style={{ alignContent: "center" }}>Copa</h2>
                        <h3>Resultado Final.</h3>
                        <h4>Veja o resultado da copa de forma simples e rapida.</h4>
                    </div>
                </div>
                <div className="container">
                    <ul>
                        {
                            this.state.vencedores.map((e, i) => {
                                return (<li>{i + 1}&#186; {e.nome}</li>)
                            })
                        }
                    </ul>
                </div>
            </div>
        );
    }
}
