import React, { Component } from 'react';
import DataGridExp from '../../libs/components/forms/DataGridExp';
import { coalitionStore } from '../../stores/coalitionStore';
import { CoalitionDetail } from '../../libs/components/details/CoalitionDetail';

const columns = [
  { dataField: 'id', caption: 'Id', dataType: 'number', allowEditing: false },
  { dataField: 'name', caption: 'Name', dataType: 'string', validationRules: [
      { type: 'required' },
      { type: 'stringLength', min: 1, max: 100 }
  ] },
  { dataField: 'color', caption: 'Color', dataType: 'string', validationRules: [
      { type: 'stringLength', min: 4, max: 7 },
      { type: 'pattern', pattern: /^#[A-Fa-f0-9]{3,6}$/g }
  ]},
];

export class Coalitions extends Component {
  constructor(props) {
    super(props);
  };

  render() {
    return (
      <>
        <DataGridExp columns={columns} detailComponent={CoalitionDetail} store={coalitionStore}/>
      </>
    );
  }
};

export default Coalitions;