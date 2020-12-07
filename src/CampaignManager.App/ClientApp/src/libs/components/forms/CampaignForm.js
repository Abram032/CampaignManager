import { Form, SimpleItem, GroupItem, StringLengthRule, RequiredRule, ButtonItem } from 'devextreme-react/form';
import React, { Component } from 'react';
import 'devextreme/ui/switch';
import 'devextreme-react/text-area';


export class CampaignForm extends Component {
  constructor(props) {
    super(props);
    this.descriptionOptions = { height: 140 };
    this.buttonOptions = {
      text: this.props.submitText,
      type: 'success',
      useSubmitBehavior: true
    };
    this.switchOptions = {
      width: 75,
      switchedOffText: 'Inactive',
      switchedOnText: 'Active'
    };
  }

  render() {
    return (
      <Form formData={this.props.campaign}>
        <GroupItem colCount={2}>
          <SimpleItem dataField='name' label='Name'>
            <RequiredRule />
          </SimpleItem>
          <SimpleItem dataField='abbreviation' label='Abbreviation'>
            <RequiredRule />
            <StringLengthRule max={10} />
          </SimpleItem>
          <SimpleItem dataField='description' label='Description' colSpan={2} editorType='dxTextArea' editorOptions={this.descriptionOptions}>
            <StringLengthRule max={10000} />
          </SimpleItem>
        </GroupItem>
        <GroupItem colCount={4}>
          <SimpleItem dataField='currency' label='Currency'>
            <RequiredRule />
            <StringLengthRule max={10} />
          </SimpleItem>
          <SimpleItem dataField='startDate' label='Start date' editorType='dxDateBox'>
            <RequiredRule />
          </SimpleItem>
          <SimpleItem dataField='endDate' label='End date' editorType='dxDateBox'/>
          <SimpleItem dataField='isActive' label='Is active?' editorType='dxSwitch' editorOptions={this.switchOptions}/>
        </GroupItem>
        <ButtonItem horizontalAlignment="right"
          buttonOptions={this.buttonOptions}
        />
      </Form>
    );
  }
}

export default CampaignForm;
