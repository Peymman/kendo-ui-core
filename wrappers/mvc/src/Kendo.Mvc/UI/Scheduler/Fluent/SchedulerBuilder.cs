﻿namespace Kendo.Mvc.UI.Fluent
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Defines the fluent interface for configuring the <see cref="Scheduler"/>.
    /// </summary>
    public class SchedulerBuilder<TModel> : WidgetBuilderBase<Scheduler<TModel>, SchedulerBuilder<TModel>> where TModel : class, ISchedulerEvent
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="Scheduler"/> class.
        /// </summary>
        /// <param name="component">The component.</param>
        public SchedulerBuilder(Scheduler<TModel> component)
            : base(component)
        {
        }

        /// <summary>
        /// Configures the Scheduler Resources
        /// </summary>
        /// <param name="addResourceAction">The client events action.</param>
        /// <example>
        /// <code lang="CS">
        /// @(Html.Kendo().Scheduler&lt;Task&gt;()
        ///    .Name(&quot;Scheduler&quot;)
        ///    .Resources(resource =&gt;
        ///    {
        ///        resource.Add(m =&gt; m.TaskID)
        ///            .Title(&quot;Color&quot;)
        ///            .Multiple(true)
        ///            .DataTextField(&quot;Text&quot;)
        ///            .DataValueField(&quot;Value&quot;)
        ///            .DataSource(d =&gt; d.Read(&quot;Attendies&quot;, &quot;Scheduler&quot;));
        ///    })
        ///    .DataSource(dataSource =&gt; dataSource
        ///        .Model(m =&gt; m.Id(f =&gt; f.TaskID))
        ///    ))
        /// </code>
        /// </example>
        public SchedulerBuilder<TModel> Resources(Action<SchedulerResourceFactory<TModel>> addResourceAction)
        {
            SchedulerResourceFactory<TModel> factory = new SchedulerResourceFactory<TModel>(Component);

            addResourceAction(factory);

            return this;
        }

        /// <summary>
        /// Configures the client-side events.
        /// </summary>
        /// <param name="clientEventsAction">The client events action.</param>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().Scheduler&lt;Task&gt;()
        ///             .Name(&quot;Scheduler&quot;)
        ///             .Events(events =&gt;
        ///                 events.Remove(&quot;remove&quot;)
        ///             )
        /// %&gt;
        /// </code>
        /// </example>
        public SchedulerBuilder<TModel> Events(Action<SchedulerEventBuilder> clientEventsAction)
        {
            clientEventsAction(new SchedulerEventBuilder(Component.Events));

            return this;
        }

        /// <summary>
        /// Binds the scheduler to a list of objects
        /// </summary>
        /// <param name="dataSource">The data source.</param>
        /// <example>
        /// <code lang="ASPX">
        /// @model IEnumerable&lt;Task&gt;
        /// &lt;%@Page Inherits=&quot;System.Web.Mvc.ViewPage&lt;IEnumerable&lt;Task&gt;&gt;&quot; %&gt;
        /// &lt;: Html.Kendo().Scheduler&lt;Task&gt;()
        ///    .Name(&quot;Scheduler&quot;)
        ///    .BindTo(Model)
        ///    .DataSource(dataSource =&gt; dataSource
        ///        .Model(m =&gt; m.Id(f =&gt; f.TaskID))
        ///    )&gt;
        /// </code>
        /// <code lang="Razor">
        /// @model IEnumerable&lt;Task&gt;
        /// @(Html.Kendo().Scheduler&lt;Task&gt;()
        ///    .Name(&quot;Scheduler&quot;)
        ///    .BindTo(Model)
        ///    .DataSource(dataSource => dataSource
        ///        .Model(m => m.Id(f => f.TaskID))
        ///    ))
        /// </code>
        /// </example>
        public SchedulerBuilder<TModel> BindTo(IEnumerable<TModel> dataSource)
        {
            Component.DataSource.Data = dataSource;

            return this;
        }
        
        /// <summary>
        /// Configures the DataSource options.
        /// </summary>
        /// <param name="configurator">The DataSource configurator action.</param>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().Scheduler&lt;Task&gt;()
        ///             .Name("Scheduler")
        ///             .DataSource(source =&gt;
        ///             {
        ///                 source.Read(read =&gt;
        ///                 {
        ///                     read.Action("Read", "Scheduler");
        ///                 }
        ///             })
        /// %&gt;
        /// </code>
        /// </example>
        /// 
        public SchedulerBuilder<TModel> DataSource(Action<AjaxDataSourceBuilder<TModel>> configurator)
        {

            configurator(new AjaxDataSourceBuilder<TModel>(Component.DataSource, this.Component.ViewContext, this.Component.UrlGenerator));

            return this;
        }

    }
}
