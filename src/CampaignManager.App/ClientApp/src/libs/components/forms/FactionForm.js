import React, { Component } from 'react';
import DataGridExp from '../forms/DataGridExp';
import { factionStore } from '../../../stores/factionStore';
import { coalitionStore } from '../../../stores/coalitionStore';
import { countryStore } from '../../../stores/countryStore';

const columns = [
  { dataField: 'id', caption: 'Id', dataType: 'number', allowEditing: false },
  { dataField: 'name', caption: 'Name', dataType: 'string', validationRules: [
    { type: 'required' },
    { type: 'stringLength', min: 1, max: 100 }
  ]},
  { dataField: 'coalitionId', caption: 'Coalition', validationRules: [
      { type: 'required' }
    ], lookup: {
      dataSource: coalitionStore,
      valueExpr: 'id',
      displayExpr: 'name'
  }},
  { dataField: 'countryId', caption: 'Country', validationRules: [
      { type: 'required' }
    ], lookup: {
      dataSource: countryStore,
      valueExpr: 'id',
      displayExpr: 'name'
  }},
  { dataField: 'budget', caption: 'Budget', dataType: 'number', format: 'currency', 
    editorOptions: { format: 'currency' }, validationRules: [
      { type: 'range', min: 0, max: 79228162514264337593543950335 }
  ]}
];

export class FactionForm extends Component {
  render() {
    return (
      <>
        <DataGridExp columns={columns} store={this.props.store} options={this.props.options}/>
      </>
    );
  }
};

export default FactionForm;