﻿using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml.Serialization;

namespace XOscillo
{
   public class DigitalVizForm : VizForm
   {
      protected GraphDigital gd;

      public DigitalVizForm(GraphDigital gd)
         : base()
      {
         this.gd = gd;
      }

      public DigitalVizForm()
         : this(new GraphDigital())
      {
      }

      public DigitalVizForm(DigitalVizForm avf)
         : this(new GraphDigital(avf.gd))
      {
      }

      public override bool Init()
      {
         graphControl.SetRenderer(gd);

         return true;
      }


      override public VizForm Clone()
      {
         SerializationHelper sh = new SerializationHelper();
         sh.dataBlock = this.GetDataBlock();
         sh.graph = new Graph(gd);

         FileDigitalVizForm avf = new FileDigitalVizForm(sh);
         avf.MdiParent = MdiParent;
         avf.Text = Text;// +Parent.childFormNumber++;
         avf.Init();
         avf.Show();
         return avf;
      }

      public override void SaveXML(FileStream stream)
      {
         SerializationHelper sh = new SerializationHelper();
         sh.dataBlock = this.graphControl.GetScopeData();
         sh.graph = new Graph(gd);

         sh.SaveXML(stream);
      }

   }
}
