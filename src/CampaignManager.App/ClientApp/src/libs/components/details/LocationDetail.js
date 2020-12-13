import React, { Component } from 'react';
import DataGridExp from '../forms/DataGridExp';
import { campaignEntityStore } from '../../../stores/campaignEntityStore';
import { locationStore } from '../../../stores/locationStore';
import { entityStore } from '../../../stores/entityStore';

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
  { dataField: 'locationId', caption: 'Location', validationRules: [
    { type: 'required' }
  ], lookup: {
    dataSource: locationStore,
    valueExpr: 'id',
    displayExpr: 'name'
  }},
  { dataField: 'entityId', caption: 'Entity', validationRules: [
    { type: 'required' }
  ], lookup: {
    dataSource: entityStore,
    valueExpr: 'id',
    displayExpr: 'name'
  }},
  { dataField: 'status', caption: 'Status', validationRules: [
    { type: 'required' }
    ], lookup: {
      dataSource: statuses,
      valueExpr: 'id',
      displayExpr: 'name'
  }},
  { dataField: 'count', caption: 'Count', dataType: 'number', 
    validationRules: [
      { type: 'range', min: 0, max: 79228162514264337593543950335 }
  ]}
];

export class LocationDetail extends React.Component {
  constructor(props) {
    super(props);

    this.data = this.props.data.data;

    this.state = {
      options: { 
        expr: 'locationId',
        value: this.data.id
      },
    }

    this.onRowInserting = this.onRowInserting.bind(this);
  }

  onRowInserting(options) {
    options.data = { ...options.data, campaignId: parseInt(this.data.campaignId) }
  }

  render() {
    return (
      <>
        <DataGridExp columns={columns} store={campaignEntityStore} options={this.state.options} onRowInserting={this.onRowInserting}/>
      </>
    );
  }
}

export default LocationDetail;
