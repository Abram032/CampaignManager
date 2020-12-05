import React, { Component } from 'react';
import DataGridExp from '../../libs/components/forms/DataGridExp';
import { countryStore } from '../../stores/countryStore';

const columns = [
  { dataField: 'id', caption: 'Id', dataType: 'number', allowEditing: false },
  { dataField: 'name', caption: 'Name', dataType: 'string', validationRules: [
    { type: 'required' },
    { type: 'stringLength', min: 1, max: 100 }
  ]},
  { dataField: 'flag', caption: 'Flag', dataType: 'string', validationRules: [
    { type: 'stringLength', min: 2, max: 20 }
  ]}
];

export class Countries extends Component {
  constructor(props) {
    super(props);
  };

  render() {
    return (
      <>
        <h1 className="display-4">Countries</h1>
        <DataGridExp columns={columns} store={countryStore}/>
      </>
    );
  }
};

export default Countries;