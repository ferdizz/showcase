import React, { Component } from 'react';
import PropTypes from 'prop-types';

class Graph extends Component {

    constructor(props) {
        super(props)
        this.state = {
            sum: '',
            dato: ''
        }
        console.log(this)
        this.onChangeSum = this.onChangeSum.bind(this);
        this.onChangeDate = this.onChangeDate.bind(this);
    }

    onChangeSum(e) {
        this.setState({ [e.target.name]: e.target.value })
    }

    onChangeDate(e) {
        this.setState({ [e.target.name]: e.target.value })
    }

    simulate() {
        console.log('Simulating')
        this.state = {
            sum: '',
            dato: ''
        }
    }

    render() {
        return (
            <div className="simulate" >
                <h2>Simuler kjøp</h2>
                <div className="sum" >
                    <p>Beløp: </p>
                    <input type="text" value={this.state.sum} name="sum" onChange={this.onChangeSum} />
                </div>
                <div className="dato" >
                    <p>Dato: </p>
                    <input type="text" value={this.state.dato} name="dato" onChange={this.onChangeDate} />
                </div>
                <button onClick={this.simulate()} >Simuler</button>
            </div>
        )
    }

}

export default Graph;