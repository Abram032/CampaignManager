import React, { Component } from 'react';
import DataGridExp from '../../libs/components/forms/DataGridExp';
import { coalitionStore } from '../../stores/coalitionStore';
import { CoalitionDetail } from '../../libs/components/details/CoalitionDetail';
import { 
  Column,
  StringLengthRule,
  RequiredRule,
  PatternRule
} from 'devextreme-react/data-grid';

const columns = (
  [
    <Column dataField='id' caption='Id' dataType='number' allowEditing={false} />,
    <Column dataField='name' caption='Name' dataType='string'>
      <RequiredRule />
      <StringLengthRule min={1} max={100} />
    </Column>,
    <Column dataField='color' caption='Color' dataType='string'>
      <StringLengthRule min={4} max={7} />
      <PatternRule pattern={/^#[A-Fa-f0-9]{3,6}$/g} />
    </Column>,
  ]
);

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