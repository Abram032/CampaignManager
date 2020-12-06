import React, { Component } from 'react';
import DataGridExp from '../../libs/components/forms/DataGridExp';
import { coalitionStore } from '../../stores/coalitionStore';
import { CoalitionDetail } from '../../libs/components/details/CoalitionDetail';

const columns = [
  { dataField: 'id', caption: 'Id', dataType: 'number', allowEditing: false },
  { dataField: 'name', caption: 'Name', dataType: 'string', validationRules: [
    { type: 'required' },
    { type: 'stringLength', min: 1, max: 100 }
  ]},
  { dataField: 'color', caption: 'Color', dataType: 'string', validationRules: [
    { type: 'pattern', pattern: /^#[A-Fa-f0-9]{3,6}$/g },
    { type: 'stringLength', min: 4, max: 7 }
  ]}
];

export class Coalitions extends Component {
  render() {
    return (
      <>
        <h1 className="display-4">Coalitions</h1>
        <DataGridExp columns={columns} detailComponent={CoalitionDetail} store={coalitionStore}/>
      </>
    );
  }
};

export default Coalitions;