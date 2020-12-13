import React, { Component } from 'react';
import DataGridExp from '../forms/DataGridExp';
import { factionStore } from '../../../stores/factionStore';
import { LocationDetail } from '../details/LocationDetail';

const statuses = {
  store: {
    type: 'array',
    data: [
      { id: 0, name: 'Unknown' },
      { id: 1, name: 'Destroyed' },
      { id: 2, name: 'Disabled' },
      { id: 3, name: 'Maintanence' },
      { id: 4, name: 'Operational' }
    ],
    key: 'id'
  }
}

const columns = [
  { dataField: 'id', caption: 'Id', dataType: 'number', allowEditing: false },
  { dataField: 'name', caption: 'Name', dataType: 'string', validationRules: [
    { type: 'required' },
    { type: 'stringLength', min: 1, max: 100 }
  ]},
  { dataField: 'factionId', caption: 'Faction', validationRules: [
      { type: 'required' }
    ], lookup: {
      dataSource: factionStore,
      valueExpr: 'id',
      displayExpr: 'name'
  }},
  { dataField: 'longitude', caption: 'Longitude', dataType: 'number', format: 'fixedPoint' },
  { dataField: 'latitude', caption: 'Latitude', dataType: 'number', format: 'fixedPoint' },
  { dataField: 'status', caption: 'Status', validationRules: [
    { type: 'required' }
    ], lookup: {
      dataSource: statuses,
      valueExpr: 'id',
      displayExpr: 'name'
  }},
];

export class LocationForm extends Component {
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
        <DataGridExp 
          columns={columns} 
          store={this.props.store} 
          options={this.props.options} 
          onRowInserting={this.onRowInserting} 
          detailComponent={LocationDetail}
        />
      </>
    );
  }
};

export default LocationForm;