import React, { Component } from 'react';
import PropTypes from 'prop-types';
import { VictoryChart, VictoryArea } from 'victory';

class Graph extends Component {

    // getData() {
    //     data = {}
    //     for (let i = 0; i < 31; i++) {

    //     }
    // }

    render() {
        return (
            <VictoryChart width={1000} height={500}>
                <VictoryArea

                    style={{
                        data: { strokeWidth: 2, fillOpacity: 1, fill: "lightgreen", stroke: "green" }
                    }}

                    interpolation="natural"

                    data={[
                        { x: 'Today', y: 25000 },
                        { x: '8/3', y: 23000 },
                        { x: '12/3', y: 20000 },
                        { x: '16/3', y: 17000 },
                        { x: '20/3', y: 15000 },
                        { x: '24/3', y: 12000 },
                        { x: '28/3', y: 8000 },
                        { x: '31/3', y: 5000 },
                        { x: '1/4', y: 22000 },
                        { x: '5/4', y: 20000 },
                    ]}
                />
            </VictoryChart>
        )
    }

}

export default Graph;