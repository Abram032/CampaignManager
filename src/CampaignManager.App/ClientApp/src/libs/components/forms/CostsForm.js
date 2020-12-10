import React, { Component } from 'react';
import DataGridExp from '../forms/DataGridExp';
import { entityStore } from '../../../stores/entityStore';

const columns = [
  { dataField: 'id', caption: 'Id', dataType: 'number', allowEditing: false },
  { dataField: 'entityId', caption: 'Entity', validationRules: [
      { type: 'required' }
    ], lookup: {
      dataSource: entityStore,
      valueExpr: 'id',
      displayExpr: 'name'
  }},
  { dataField: 'cost', caption: 'Cost', dataType: 'number', format: 'currency', 
    editorOptions: { format: 'currency' }, validationRules: [
      { type: 'range', min: 0, max: 79228162514264337593543950335 }
  ]}
];

export class CostsForm extends Component {
  constructor(props) {
    super(props);
    this.onRowInserting = this.onRowInserting.bind(this);
  }

  onRowInserting(options) {
    options.data = { ...options.data, campaignId: parseInt(this.props.campaignId) }
  }

  render() {
    return (
      <>
        <DataGridExp columns={columns} store={this.props.store} options={this.props.options} onRowInserting={this.onRowInserting}/>
      </>
    );
  }
};

export default CostsForm;