using ComputerShop.model.database;
using ComputerShop.model.repository.implementations;
using ComputerShop.view.adminTools;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ComputerShop.viewmodel.adminTools
{
	class StatsViewModel
	{
		public StatsUC CodeBehind { get; set; }
		public OrderRepository OrderRepository { get; set; }
		public SupplyRepository SupplyRepository { get; set; }
		public PlotModel Plot { get; set; }

		public StatsViewModel(StatsUC codeBehind)
		{
			OrderRepository = new OrderRepository();
			SupplyRepository = new SupplyRepository();
			CodeBehind = codeBehind;

			List<Order> approvedOrders = OrderRepository.FindByPredicate(order => order.State == State.Approved).ToList();
			List<Supply> supplies = SupplyRepository.GetAll();

			DateTime today = DateTime.Now.Date;
			DateTime monthAgo = today.AddMonths(-1);

			Plot = new PlotModel();
			Plot.LegendPosition = LegendPosition.TopCenter;
			Plot.Title = "Статистика за месяц";

			LineSeries income = new LineSeries() { Color = OxyColor.FromRgb(0, 200, 0), Title = "Доходы" };
			LineSeries consumption = new LineSeries() { Color = OxyColor.FromRgb(200, 0, 0), Title = "Расходы" };
			LineSeries profit = new LineSeries() { Color = OxyColor.FromRgb(200, 150, 0), Title = "Прибыль" };
			LineSeries axis = new LineSeries() { Color = OxyColor.FromRgb(0, 0, 0) };

			decimal incomeOfDay = 0;
			decimal consumptionOfDay = 0;

			Plot.Axes.Add(new DateTimeAxis 
			{ 
				Position = AxisPosition.Bottom, 
				AbsoluteMinimum = DateTimeAxis.ToDouble(monthAgo), 
				AbsoluteMaximum = DateTimeAxis.ToDouble(today), 
				StringFormat = "dd MMMM",
				Title = "Дата",
				TitleFontWeight = OxyPlot.FontWeights.Bold
			});

			Plot.Axes.Add(new LinearAxis
			{
				Position = AxisPosition.Left,
				Title = "б.р.",
				TitleFontWeight = OxyPlot.FontWeights.Bold
			});

			for (DateTime date = monthAgo; date <= today; date = date.AddDays(1))
			{
				incomeOfDay += approvedOrders
					.Where(order => order.Date > date && order.Date <= date.AddDays(1))
					.Sum(order => order.Ordered.Sum(ordered => ordered.Product.Price * ordered.Amount));

				consumptionOfDay += supplies
					.Where(supply => supply.Date > date && supply.Date <= date.AddDays(1))
					.Sum(supply => supply.DeliveredToWareHouse.Sum(delivered => delivered.Price * delivered.Amount));
				
				double incomeDouble = Convert.ToDouble(incomeOfDay);
				double consumptionDouble = Convert.ToDouble(consumptionOfDay);

				income.Points.Add(new DataPoint(DateTimeAxis.ToDouble(date), incomeDouble));
				consumption.Points.Add(new DataPoint(DateTimeAxis.ToDouble(date), consumptionDouble));
				profit.Points.Add(new DataPoint(DateTimeAxis.ToDouble(date), incomeDouble - consumptionDouble));
				axis.Points.Add(new DataPoint(DateTimeAxis.ToDouble(date), 0));

			}

			Plot.Series.Add(axis);
			Plot.Series.Add(income);
			Plot.Series.Add(consumption);
			Plot.Series.Add(profit);
			
 		}
	}
}
